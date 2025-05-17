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

    server.post("/create-song", routes::create::create_song::post).unwrap();
    server.post("/create-album", routes::create::create_album::post).unwrap();
    server.post("/create-artist", routes::create::create_artist::post).unwrap();

    server.new_static("/song", "./songs").unwrap();

    server.new_static("/image", "./images").unwrap();

    server
        .listen(3000, None, None, || {
            println!("Dante server started on port 3000!");
        })
        .unwrap();

    Server::<u8>::lock();
}
