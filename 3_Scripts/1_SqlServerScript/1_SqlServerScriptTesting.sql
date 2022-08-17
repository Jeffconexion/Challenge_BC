--------------------------------------
-- SCRIPT UTILIZADO PARA TESTE -------
--------------------------------------

-----> 1º
-- CREATE DATABASE
CREATE DATABASE DB_CHALLENGE_TESTE;

-----> 2º
-- USE DATABASE
USE DB_CHALLENGE_TESTE;

-----> 3º
-- CREATE TABLE CUSTOMER
CREATE TABLE TB_CUSTUMER(
    id uniqueidentifier primary key,
    name varchar(60) not null,
    tax_id varchar(25) not null,
    password varchar(30) not null,
    phone_number varchar(30) null,
    created_at datetime DEFAULT GETDATE()
);


-----> 4º
-- CREATE TABLE STATUS
CREATE TABLE TB_STATUS_ADDRESS(
   id uniqueidentifier primary key,
   status varchar(10)
);

-----> 5º
-- CREATE TABLE ADDRESS
CREATE TABLE TB_ADDRESS(
   id uniqueidentifier primary key,
   id_custumer uniqueidentifier FOREIGN KEY REFERENCES TB_CUSTUMER(id),
   id_status_address uniqueidentifier FOREIGN KEY REFERENCES TB_STATUS_ADDRESS(id),
   state varchar(4),
   city varchar(200),
   district varchar(200),
   address varchar(200),
   code varchar(200)
);


-----> 6º
-- CREATE VIEW ALL DATE
CREATE VIEW VW_FULLDATA_CUSTUMER
AS
SELECT c.name, c.tax_id, c.phone_number, c.created_at, a.code, a.address, a.district, a.city, a.state, s.status
FROM TB_CUSTUMER c
inner join TB_ADDRESS a
ON c.id = a.id_custumer
inner join TB_STATUS_ADDRESS s
ON s.id = a.id_status_address;

