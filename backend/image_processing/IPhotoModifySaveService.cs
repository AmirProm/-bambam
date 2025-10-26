using Microsoft.AspNetCore.Http;
using MongoDB.Bson;

namespace image_processing.Interfaces;

public interface IPhotoModifySaveService
{
    public Task<string> ResizeImageByScale(IFormFile formFile, ObjectId userId, int standardSizeIndex);
    public Task<string> ResizeByPixel(IFormFile formFile, ObjectId userId, int widthIn, int heightIn);
    public Task<string> ResizeByPixel_Square(IFormFile formFile, ObjectId userId, int side);
    public Task<string> Crop(IFormFile formFile, ObjectId userId, int widthIn, int heightIn);
    public Task<string> Crop_Square(IFormFile formFile, ObjectId userId, int side);
    public Task<string> CropWithOriginalSide_Square(IFormFile formFile, ObjectId userId);
    public Task<string> SaveImageAsIs(IFormFile formFile, ObjectId userId, int operation);
}