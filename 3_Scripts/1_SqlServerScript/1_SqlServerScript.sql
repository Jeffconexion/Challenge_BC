/* 
<summary>
/// @author: Jefferson Santos
/// @Data  : 05/07/2022
/// 
/// File with the sql scripts used to create the ApiRegisterCustomer
/// ~~> Be careful when modifying this file!
</summary>
*/

-- ~~> DROP DATABASE <~~
DROP DATABASE DB_CHALLENGE_BC;  

-- ~~> DROP TABLE <~~
DROP TABLE TB_STATUS_ADDRESS;
DROP TABLE TB_CUSTUMER;
DROP TABLE TB_ADDRESS;

-----> 1�
-- CREATE DATABASE
CREATE DATABASE DB_CHALLENGE_BC;

-----> 2�
-- USE DATABASE
USE DB_CHALLENGE_BC;

-----> 3�
-- CREATE TABLE CUSTOMER
CREATE TABLE TB_CUSTUMER(
    id uniqueidentifier primary key,
    name varchar(60) not null,
    tax_id varchar(25) not null,
    password varchar(30) not null,
    phone_number varchar(max) null,
    created_at datetime DEFAULT GETDATE()
);

-----> 4�
-- CREATE TABLE STATUS
CREATE TABLE TB_STATUS_ADDRESS(
   id uniqueidentifier primary key,
   status varchar(10)
);

-----> 5�
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

-----> 6�
-- CREATE VIEW ALL DATE
CREATE VIEW VW_FULLDATA_CUSTUMER
AS
SELECT c.name, c.tax_id, c.phone_number, c.created_at, a.code, a.address, a.district, a.city, a.state, s.status
FROM TB_CUSTUMER c
inner join TB_ADDRESS a
ON c.id = a.id_custumer
inner join TB_STATUS_ADDRESS s
ON s.id = a.id_status_address;


-- SELECTS
SELECT * FROM TB_CUSTUMER;
SELECT * FROM TB_STATUS_ADDRESS;
SELECT * FROM TB_ADDRESS;

-- SELECT VW_FULLDATA_CUSTUMER
SELECT * FROM VW_FULLDATA_CUSTUMER;

-- DELETE DATA FROM TABLE
DELETE FROM TB_ADDRESS
DELETE FROM TB_CUSTUMER
DELETE FROM TB_STATUS_ADDRESS
