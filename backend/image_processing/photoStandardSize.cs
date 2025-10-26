namespace image_processing.Helpers;

public class PhotoStandardSize
{
    private protected record StandardSize(
        int Side1,
        int Side2
    );

    // public enum WeekDaysEnum
    // {
    //     Satureday,
    //     Sunday,
    //     Monday
    // }
    protected enum DimensionsEnum
    {
        // 4:3
        _4_3_640x480,
        _4_3_800x600,
        _4_3_960x720,
        _4_3_1024x768,
        _4_3_1280x960,
        _4_3_1400x1050,
        _4_3_1600x1200,
        _4_3_1856x1392,
        _4_3_1920x1440,
        _4_3_2048x1536,

        // 4:9
        _4_9_1080x566,
        _4_9_960x540,
        _4_9_828x464,
        _4_9_750x422,
        _4_9_640x360,
        _4_9_576x324,
        _4_9_500x283,
        _4_9_480x270,
        _4_9_400x234,
        _4_9_320x180,
    }

    private protected static readonly StandardSize[] dimensions = [
        // 4:3
        new StandardSize( 640, 480),
        new StandardSize( 800, 600),
        new StandardSize( 960, 720),
        new StandardSize( 1024, 768),
        new StandardSize( 1280, 960),
        new StandardSize( 1400, 1050),
        new StandardSize( 1600, 1200),
        new StandardSize( 1856, 1392),
        new StandardSize( 1920, 1440),
        new StandardSize( 2048, 1536),

        // 4:9
        new StandardSize( 1080, 566),
        new StandardSize( 960, 540),
        new StandardSize( 828, 464),
        new StandardSize( 750, 422),
        new StandardSize( 640, 360),
        new StandardSize( 576, 324),
        new StandardSize( 500, 283),
        new StandardSize( 480, 270),
        new StandardSize( 400, 234),
        new StandardSize( 320, 180)
    ];
}