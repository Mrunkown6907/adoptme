CREATE TABLE customer (
    customer_id varchar(255) PRIMARY KEY,
    phone_num int NOT NULL,
    email varchar(255) NOT NULL CHECK (email LIKE '%@%'),
    address varchar(255) NOT NULL,
    nama char(255) NOT NULL,
    pass char(255) NOT NULL,
    saldo int NOT NULL
);

CREATE TABLE shop (
    shop_id varchar(255) NOT NULL PRIMARY KEY,
    shop_phone_number int NOT NULL,
    shop_address varchar(255) NOT NULL,
    shop_name varchar(255) NOT NULL,
    shop_pass varchar(255) NOT NULL,
    shop_saldo int NOT NULL,
    rating int NOT NULL,
    CONSTRAINT chk_shop_id CHECK (shop_id LIKE 'SH[0-9][0-9][0-9]')
);

CREATE TABLE pet (
    pet_id varchar(255) NOT NULL PRIMARY KEY,
    shop_id varchar(255) NOT NULL,
    pet_name char(255) NOT NULL,
    umur int NOT NULL,
    price int NOT NULL,
    gender char(10) NOT NULL CHECK (gender IN ('male', 'female')),
    species char(255) NOT NULL,
    pet_image_path varchar(255) NOT NULL,
    CONSTRAINT fk_shop_id_pet FOREIGN KEY (shop_id) REFERENCES shop(shop_id) ON DELETE CASCADE,
    CONSTRAINT pet_id_format CHECK (pet_id LIKE 'PET[0-9][0-9][0-9]')
);


CREATE TABLE item (
    item_id varchar(255) NOT NULL PRIMARY KEY,
    shop_id varchar(255) NOT NULL,
    item_name char(255) NOT NULL,
    inventory int NOT NULL,
    expiration_date datetime NOT NULL,
    price int NOT NULL,
    item_image_path varchar(255) NOT NULL,
    CONSTRAINT fk_shop_id_item FOREIGN KEY (shop_id) REFERENCES shop(shop_id) ON DELETE CASCADE,
    CONSTRAINT chk_item_id CHECK (item_id LIKE 'IT[0-9][0-9][0-9]')
);

CREATE TABLE wishlist (
    customer_id varchar(255) NOT NULL,
    pet_id varchar(255),
    item_id varchar(255),
    FOREIGN KEY (customer_id) REFERENCES customer(customer_id) ON DELETE CASCADE,
    FOREIGN KEY (pet_id) REFERENCES pet(pet_id),
    FOREIGN KEY (item_id) REFERENCES item(item_id)
);

CREATE TABLE chat (
    chat_id varchar(255) NOT NULL PRIMARY KEY,
    shop_id varchar(255) NOT NULL,
    customer_id varchar(255) NOT NULL,
    FOREIGN KEY (shop_id) REFERENCES shop(shop_id) ON DELETE NO ACTION,
    FOREIGN KEY (customer_id) REFERENCES customer(customer_id) ON DELETE CASCADE,
    CONSTRAINT chk_chat_id CHECK (chat_id LIKE 'CH[0-9][0-9][0-9]')
);

CREATE TABLE transactions(
  trans_id INT PRIMARY KEY,
  customer_id varchar(255) NOT NULL,
  shop_id varchar(255) NOT NULL,
  temp_saldo INT NOT NULL,
  FOREIGN KEY (customer_id) REFERENCES customer(customer_id),
  FOREIGN KEY (shop_id) REFERENCES shop(shop_id)
);

CREATE TABLE pet_header (
    pet_header_id INT NOT NULL PRIMARY KEY,
    cart_id varchar(255) NOT NULL,
    pet_id varchar(255) NOT NULL,
    quantity int NOT NULL CHECK (quantity = 1),
    CONSTRAINT fk_cart_id_pet_header FOREIGN KEY (cart_id) REFERENCES customer(customer_id),
    CONSTRAINT fk_pet_id_pet_header FOREIGN KEY (pet_id) REFERENCES pet(pet_id),
    CONSTRAINT ck_pet_header_id CHECK (cart_id LIKE 'PTH%[0-9][0-9][0-9]')
);

CREATE TABLE item_header (
    item_header_id INT NOT NULL PRIMARY KEY,
    cart_id varchar(255) NOT NULL,
    item_id varchar(255) NOT NULL,
    quantity int NOT NULL,
    CONSTRAINT fk_cart_id_item_header FOREIGN KEY (cart_id) REFERENCES customer(customer_id),
    CONSTRAINT fk_item_id_item_header FOREIGN KEY (item_id) REFERENCES item(item_id),
    CONSTRAINT ck_item_header_id CHECK (cart_id LIKE 'ITH%[0-9][0-9][0-9]')
);

CREATE TABLE cart (
    cart_id varchar(255) NOT NULL PRIMARY KEY,
    customer_id varchar(255) NOT NULL,
    CONSTRAINT cart_id_format CHECK (cart_id LIKE 'CA%[0-9][0-9][0-9]')
);

CREATE TABLE wish_list (
    cart_id varchar(255) NOT NULL PRIMARY KEY,
    customer_id varchar(255) NOT NULL,
    CONSTRAINT fk_cart_id_wish_list FOREIGN KEY (cart_id) REFERENCES cart(cart_id)
);
