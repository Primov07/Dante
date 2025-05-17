use std::{ env, fs::{ self, File }, io::Read, path::Path };

use choki::src::{ request::Request, response::Response, structs::{ ContentType, HttpServerError } };
use mongodb::sync::Database;

use crate::{ database_managers::{ album_manager, Controller }, schemas::album::Album };

pub fn post(
    req: Request,
    mut res: Response,
    database: Option<Database>
) -> Result<(), HttpServerError> {
    let body = req.body();
    let database = database.unwrap();
    let album_manager = album_manager::AlbumManager::new(&database);

    let title = String::from_utf8_lossy(body[0].data).to_string();

    let album = Album::new(title);

    fs::write(format!("./images/album/{}.png", album.id), body[1].data).unwrap();

    let output = format!("Uploaded with id: {}", album.id);

    album_manager.create(album).unwrap();

    res.send_string(&output)
}
