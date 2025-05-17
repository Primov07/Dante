use choki::{ self, Server };

fn main() {
    let mut server: Server<u8> = Server::new(Some(10_000_000), None); // Max file upload is 10 MB

    server
        .get("/", |req, mut res, public_var| {
            return res.send_string("Wassup");
        })
        .unwrap();

    server
        .listen(3000, None, None, || {
            println!("Dante server started on port 3000!");
        })
        .unwrap();

    Server::<u8>::lock();
}
