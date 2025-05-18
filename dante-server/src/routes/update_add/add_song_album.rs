use std::{ env, fs::{ self, File }, io::Read, path::Path };

use choki::src::{ request::Request, response::Response, structs::{ ContentType, HttpServerError } };
use mongodb::sync::Database;

use crate::{ database_managers::{ album_manager, Controller }, schemas::{ album::Album, song } };

pub fn post(
    req: Request,
    mut res: Response,
    database: Option<Database>
) -> Result<(), HttpServerError> {
    let body = req.body();
    let database = database.unwrap();

    let album_manager = album_manager::AlbumManager::new(&database);

    let song_id = String::from_utf8_lossy(body[0].data).to_string();
    let album_id = String::from_utf8_lossy(body[1].data).to_string();

    let album = album_manager.find(album_id.parse().unwrap_or_default());
    if album.is_none() {
        return res.send_string("No album found!");
    }
    let mut album = album.unwrap();
    album.songs.push(song_id.parse().unwrap_or_default());

    album_manager.update(album);

    let output = format!("Added song to : {}", album_id);

    res.send_string(&output)
}
