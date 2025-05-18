use std::env;

use choki::{ self, Server };

use dotenv::dotenv;
use mongodb::sync::{ Client, Database };

mod utils;

mod schemas;
mod database_managers;

mod routes;
fn main() {
    dotenv().ok();
    // Connect mongodb
    let mut client = Client::with_uri_str(env::var("MONGO_URI").unwrap()).unwrap();

    let mut database = client.database("Dante-main");
    //

    let mut server: Server<Database> = Server::new(Some(10_000_000), Some(database)); // Max file upload is 10 MB

    server.get("/", routes::index::get).unwrap();

    server.get("/getSongs", routes::get_all::get_all_songs::get).unwrap();
    server.get("/getArtists", routes::get_all::get_all_artists::get).unwrap();
    server.get("/getAlbums", routes::get_all::get_all_albums::get).unwrap();

    // Create
    server.post("/create-song", routes::create::create_song::post).unwrap();
    server.post("/create-album", routes::create::create_album::post).unwrap();
    server.post("/create-artist", routes::create::create_artist::post).unwrap();
    // Update-Add
    server.post("/album/add-song", routes::update_add::add_song_album::post).unwrap();
    server.post("/artist/add-song", routes::update_add::add_song_artist::post).unwrap();
    server.post("/artist/add-album", routes::update_add::add_album_artist::post).unwrap();
    // Update-Remove
    server.post("/album/remove-song", routes::update_remove::remove_song_album::post).unwrap();
    server.post("/artist/remove-song", routes::update_remove::remove_song_artist::post).unwrap();
    server.post("/artist/remove-album", routes::update_remove::remove_album_artist::post).unwrap();
    // Delete
    server.post("/album/delete", routes::delete::delete_album::post).unwrap();
    server.post("/artist/delete", routes::delete::delete_artist::post).unwrap();
    server.post("/song/delete", routes::delete::delete_song::post).unwrap();

    server.new_static("/song", "./songs").unwrap();

    server.new_static("/image", "./images").unwrap();

    server
        .listen(3000, None, None, || {
            println!("Dante server started on port 3000!");
        })
        .unwrap();

    Server::<u8>::lock();
}
