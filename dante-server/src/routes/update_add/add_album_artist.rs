use std::{ env, fs::{ self, File }, io::Read, path::Path };

use choki::src::{ request::Request, response::Response, structs::{ ContentType, HttpServerError } };
use mongodb::sync::Database;

use crate::{ database_managers::{ artist_manager, Controller }, schemas::{ album::Album, song } };

pub fn post(
    req: Request,
    mut res: Response,
    database: Option<Database>
) -> Result<(), HttpServerError> {
    let body = req.body();
    let database = database.unwrap();

    let artist_manager = artist_manager::ArtistManager::new(&database);

    let album_id = String::from_utf8_lossy(body[0].data).to_string();
    let artist_id = String::from_utf8_lossy(body[1].data).to_string();

    let artist = artist_manager.find(artist_id.parse().unwrap_or_default());
    if artist.is_none() {
        return res.send_string("No album found!");
    }
    let mut artist = artist.unwrap();
    artist.albums.push(album_id.parse().unwrap_or_default());

    artist_manager.update(artist);

    let output = format!("Added album to : {}", artist_id);

    res.send_string(&output)
}
