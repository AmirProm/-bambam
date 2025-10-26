using image_processing.Helpers;
using image_processing.Interfaces;

namespace api.Services;

public class PhotoService(
    IPhotoModifySaveService _photoModifyService,
    ILogger<PhotoService> _logger
    ) : PhotoStandardSize, IPhotoService
{
    #region Constructor and variables

    const string wwwRootUrl = "wwwroot/";

    #endregion

    /// <summary>
    /// ADD PHOTO TO DISK
    /// Store photos on disk by creating a folder based on fileName, userId, size, crop, etc. Each user will have a folder named after their db _Id.
    /// Resize and square image with 165px(navbar & thumbnail), 256px(card).
    /// Scale image to a ~300kb max size for the enlarged gallery photo.
    /// Store photo address in db as "storage/photos/user-id/resize-pixel-square/128x128/my-photo.jpg"
    /// 
    /// DELETE PHOTO FROM DISK
    /// </summary>
    /// <param name="formFile"></param>
    /// <param name="userId"></param>
    /// <returns>ADD: array of filePaths. DELETE: boolean</returns>
    public async Task<string[]?> AddPhotoToDiskAsync(IFormFile formFile, ObjectId userId)
    {
        // copy file/s to the folder
        if (formFile.Length > 0) // 301kb => 301_000 byte
        {
            #region Resize and/or Store Images to Disk
            // await _photoModifyService.Crop(formFile, userId, 450, 800);
            // await _photoModifyService.Crop_Square(formFile, userId, 400);
            // await _photoModifyService.CropWithOriginalSide_Square(formFile, userId);
            // await _photoModifyService.ResizeByPixel(formFile, userId, 500, 800);
            // await _photoModifyService.ResizeByPixel_Square(formFile, userId, 500);
            // await _photoModifyService.ResizeImageByScale(formFile, userId);

            string filePath_165_sq = await _photoModifyService.ResizeByPixel_Square(formFile, userId, 165); // navbar & thumbnail
            string filePath_256_sq = await _photoModifyService.ResizeByPixel_Square(formFile, userId, 256); // card
            string filePath_enlarged = await _photoModifyService.ResizeImageByScale(formFile, userId, (int)DimensionsEnum._4_3_800x600); // enlarged photo
            // string filePath_enlarged2 = await _photoModifyService.ResizeImageByScale(formFile, userId, (int)DimensionsEnum._4_3_1280x960); // enlarged photo

            // if conversion fails
            if (filePath_165_sq is null || filePath_256_sq is null || filePath_enlarged is null)
            {
                _logger.LogError("Photo addition failed. The returned filePath is null which is not allowed.");
                return null;
            }
            #endregion Resize and Create Images to Disk

            #region Create the photo URLs and return the result
            // // generate "wwwroot/storage/photos/user-id/resize-pixel-square/128x128/my-photo.jpg"
            return [
                filePath_165_sq.Split(wwwRootUrl)[1], // 0
                filePath_256_sq.Split(wwwRootUrl)[1], // 1
                filePath_enlarged.Split(wwwRootUrl)[1] // 2

                // string name = "amirRshaghaghi";
                // string[] names = name.Split("R"); // ["amir", "shaghaghi"];
                // names[0] // "amir"
            ];
            #endregion
        }

        return null;
    }

    /// <summary>
    /// Delete all files of the requested photo to be deleted.
    /// </summary>
    /// <param name="photo"></param>
    /// <returns>bool</returns>
    public async Task<bool> DeletePhotoFromDisk(Photo photo)
    {
        List<string> photoPaths = [];

        photoPaths.Add(photo.Url_165);
        photoPaths.Add(photo.Url_256);
        photoPaths.Add(photo.Url_enlarged);

        foreach (string photoPath in photoPaths)
        {
            if (File.Exists(wwwRootUrl + photoPath))
            {
                // Delete the file on a background thread and await the task
                await Task.Run(() => File.Delete(wwwRootUrl + photoPath));
            }
            else
                return false;
        }

        return true;
    }
}