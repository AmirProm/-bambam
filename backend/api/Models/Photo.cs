namespace api.Models;

public record Photo(
    string Url_165, // navbar 165 * 165 10kB
    string Url_256, // card / thumbnail 17kB
    string Url_enlarged, // enlarged photo up to ~300kb
    bool IsMain // profile => true ELSE => false
);

/*
Faranak 10928370196501620

Folder name: 10928370196501620
    sub-folder 165x165
    sub-folder 256x256
    sub-folder enlarged
*/