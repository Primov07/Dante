use std::{ env, fs::{ self, File }, io::Read, path::Path };

use choki::src::{ request::Request, response::Response, structs::{ ContentType, HttpServerError } };
use mongodb::sync::Database;

use crate::{
    database_managers::{ album_manager, artist_manager, Controller },
    schemas::{ album::Album, artist::Artist, song },
};

pub fn post(
    req: Request,
    mut res: Response,
    database: Option<Database>
) -> Result<(), HttpServerError> {
    let body = req.body();
    let database = database.unwrap();

    let artist_manager = artist_manager::ArtistManager::new(&database);
    let album_manager = album_manager::AlbumManager::new(&database);

    let album_id = String::from_utf8_lossy(body[0].data).to_string();
    let album_id = album_id.parse().unwrap_or_default();

    let album = album_manager.find(album_id);
    if album.is_none() {
        return res.send_string("No album found!");
    }

    album_manager.delete(album_id); // Remove album

    let artists = artist_manager.get_all();
    let mut to_update: Vec<Artist> = Vec::new();

    for artist in artists {
        if artist.albums.contains(&album_id) {
            let mut artist_clone = artist;

            artist_clone.albums = artist_clone.albums
                .into_iter()
                .filter(|a| *a != album_id)
                .collect();

            to_update.push(artist_clone);
        }
    }
    for update_artist in to_update {
        artist_manager.update(update_artist);
    }
    let output = format!("Removed album : {}", album_id);

    res.send_string(&output)
}
