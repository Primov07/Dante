use std::{ env, fs::{ self, File }, io::Read, path::Path };

use choki::src::{ request::Request, response::Response, structs::{ ContentType, HttpServerError } };
use mongodb::sync::Database;

use crate::{ database_managers::{ artist_manager, Controller }, schemas::artist::Artist };

pub fn post(
    req: Request,
    mut res: Response,
    database: Option<Database>
) -> Result<(), HttpServerError> {
    let body = req.body();
    let database = database.unwrap();
    let artist_manager = artist_manager::ArtistManager::new(&database);

    let name = String::from_utf8_lossy(body[0].data).to_string();
    let genre = String::from_utf8_lossy(body[1].data).to_string();

    let artist = Artist::new(name, genre.parse::<f32>().unwrap_or_default());

    fs::write(format!("./images/artist/{}.png", artist.id), body[2].data).unwrap();

    let output = format!("Uploaded with id: {}", artist.id);

    artist_manager.create(artist).unwrap();

    res.send_string(&output)
}
