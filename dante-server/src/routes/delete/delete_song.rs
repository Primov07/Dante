use std::{ env, fs::{ self, File }, io::Read, path::Path };

use choki::src::{ request::Request, response::Response, structs::{ ContentType, HttpServerError } };
use mongodb::sync::Database;

use crate::{
    database_managers::{ album_manager, artist_manager, song_manager, Controller },
    schemas::{ album::Album, artist::Artist, song },
};

pub fn post(
    req: Request,
    mut res: Response,
    database: Option<Database>
) -> Result<(), HttpServerError> {
    let body = req.body();
    let database = database.unwrap();

    let song_manager = song_manager::SongManager::new(&database);
    let artist_manager = artist_manager::ArtistManager::new(&database);
    let album_manager = album_manager::AlbumManager::new(&database);

    let song_id = String::from_utf8_lossy(body[0].data).to_string();
    let song_id = song_id.parse().unwrap_or_default();

    let song = song_manager.find(song_id);
    if song.is_none() {
        return res.send_string("No album found!");
    }

    song_manager.delete(song_id); // Remove Song

    // Remove song from artists
    let artists = artist_manager.get_all();
    let mut to_update_artists: Vec<Artist> = Vec::new();

    for artist in artists {
        if artist.songs.contains(&song_id) {
            let mut artist_clone = artist;

            artist_clone.songs = artist_clone.songs
                .into_iter()
                .filter(|a| *a != song_id)
                .collect();

            to_update_artists.push(artist_clone);
        }
    }
    for update_artist in to_update_artists {
        artist_manager.update(update_artist);
    }
    //
    // Remove song from Albums
    let albums = album_manager.get_all();
    let mut to_update_albums: Vec<Album> = Vec::new();

    for album in albums {
        if album.songs.contains(&song_id) {
            let mut album_clone = album;

            album_clone.songs = album_clone.songs
                .into_iter()
                .filter(|a| *a != song_id)
                .collect();

            to_update_albums.push(album_clone);
        }
    }
    for update_album in to_update_albums {
        album_manager.update(update_album);
    }
    //
    let output = format!("Removed song : {}", song_id);

    res.send_string(&output)
}
