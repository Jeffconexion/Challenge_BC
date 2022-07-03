/* 
<summary>
/// @author: Jefferson Santos
/// @Data  : 03/07/2022
/// 
/// File with the sql scripts used to create the ApiRegisterCustomer
/// ~~> Be careful when modifying this file!
</summary>
*/

-- CREATE DATABASE
CREATE DATABASE DB_CHALLENGE_BC;

-- ~~> DROP DATABASE <~~
DROP DATABASE DB_CHALLENGE_BC;  

-- ~~> DROP TABLE <~~
DROP TABLE TB_STATUS_ADDRESS;
DROP TABLE TB_CUSTUMER;
DROP TABLE TB_ADDRESS;

-- ~~> EXTRA RESOURCESS  
SELECT CONVERT (datetime, GETDATE())


SELECT S.NAME       AS 'Schema',
       T.NAME       AS Tabela,
       C.NAME       AS Coluna,
       TY.NAME      AS Tipo,
       C.max_length AS 'Tamanho Máximo',-- Tamanho em bytes, para nvarchar normalmente se divide este valor por 2
       C.PRECISION  AS 'Precisão',-- Para tipos numeric e decimal (tamanho)
       C.scale      AS 'Escala'
-- Para tipos numeric e decimal (números após a virgula)
FROM   sys.columns C
       INNER JOIN sys.tables T
               ON T.object_id = C.object_id
       INNER JOIN sys.types TY
               ON TY.user_type_id = C.user_type_id
       LEFT JOIN sys.schemas S
              ON T.schema_id = S.schema_id 
--  EXTRA RESOURCESS <~~ 


-- USE DATABASE
USE DB_CHALLENGE_BC;

-- CREATE TABLE CUSTOMER
CREATE TABLE TB_CUSTUMER(
    id uniqueidentifier primary key,
    name varchar(60) not null,
    tax_id varchar(25) not null,
    password varchar(30) not null,
    phone_number varchar(max) null,
    created_at datetime DEFAULT GETDATE()
);

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

-- CREATE TABLE STATUS
CREATE TABLE TB_STATUS_ADDRESS(
   id uniqueidentifier primary key,
   status varchar(10)
);

-- CREATE VIEW ALL DATE
CREATE VIEW VW_FULLDATA_CUSTUMER
AS
SELECT c.name, c.tax_id, c.phone_number, c.created_at, a.code, a.address, a.district, a.city, a.state, s.status
FROM TB_CUSTUMER c
inner join TB_ADDRESS a
ON c.id = a.id_custumer
inner join TB_STATUS_ADDRESS s
ON s.id = a.id_status_address;


-- CREATE VIEW ALL DATE BUT STATUS PENDING
CREATE VIEW VW_FULLDATA_CUSTUMER_IS_PENDING
AS
SELECT c.name, c.tax_id, c.phone_number, c.created_at, a.code, a.address, a.district, a.city, a.state, s.status
FROM TB_CUSTUMER c
inner join TB_ADDRESS a
ON c.id = a.id_custumer
inner join TB_STATUS_ADDRESS s
ON s.id = a.id_status_address
WHERE s.status like 'PENDING'

-- CREATE VIEW ALL DATE BUT STATUS APPROVED
CREATE VIEW VW_FULLDATA_CUSTUMER_IS_APPROVED
AS
SELECT c.name, c.tax_id, c.phone_number, c.created_at, a.code, a.address, a.district, a.city, a.state, s.status
FROM TB_CUSTUMER c
inner join TB_ADDRESS a
ON c.id = a.id_custumer
inner join TB_STATUS_ADDRESS s
ON s.id = a.id_status_address
WHERE s.status like 'APPROVED'

-- SELECT VW_FULLDATA_CUSTUMER
SELECT * FROM VW_FULLDATA_CUSTUMER;
SELECT * FROM VW_FULLDATA_CUSTUMER_IS_PENDING
SELECT * FROM VW_FULLDATA_CUSTUMER_IS_APPROVED

-- SELECTS
SELECT * FROM TB_CUSTUMER;
SELECT * FROM TB_STATUS_ADDRESS;
SELECT * FROM TB_ADDRESS;

--> CREATE DATA FOR EXAMPLAS TABLE CUSTUMER
INSERT INTO dbo.TB_CUSTUMER(id,name,tax_id,password,phone_number) VALUES('99c2418e-d047-4d3e-9aec-1cb8642b1960','Marcos Silva','12335476804','123456','81987881234')
INSERT INTO dbo.TB_CUSTUMER(id,name,tax_id,password,phone_number) VALUES('c8fabecd-81a5-4c3c-bb86-f9980336ffb0','Morgana Rocha','12335476804','123456','81987881234')

-- ~~> APPROVED
INSERT INTO dbo.TB_CUSTUMER(id,name,tax_id,password,phone_number) VALUES('38e4a1b2-130e-4f6f-a587-a0ea91e8c929','Tiago Chavier','12335476804','123456','81987881234')


--> CREATE DATA FOR EXAMPLAS TABLE STATUS_ADDRESS
INSERT INTO dbo.TB_STATUS_ADDRESS(id,status) VALUES('5d5e3f3c-9e18-429b-ade8-9042bcdaf19a','PENDING')
INSERT INTO dbo.TB_STATUS_ADDRESS(id,status) VALUES('fc56d792-21d1-43a7-96bc-a3fa0e39b6d9','PENDING')

-- ~~> APPROVED
INSERT INTO dbo.TB_STATUS_ADDRESS(id,status) VALUES('12b24eb4-4c25-4c2c-86e6-0252d5bc4853','APPROVED')


--> CREATE DATA FOR EXAMPLAS TABLE ADDRESS
INSERT INTO dbo.TB_ADDRESS(id,id_custumer,id_status_address) 
VALUES
('77a037ee-5ee7-45b1-ab4f-3585b48374d5','99c2418e-d047-4d3e-9aec-1cb8642b1960','5d5e3f3c-9e18-429b-ade8-9042bcdaf19a')

INSERT INTO dbo.TB_ADDRESS(id,id_custumer,id_status_address) 
VALUES
('d0c903e4-6aa0-48f3-aec3-003c62fa9e56','c8fabecd-81a5-4c3c-bb86-f9980336ffb0','fc56d792-21d1-43a7-96bc-a3fa0e39b6d9')

-- ~~> APPROVED
INSERT INTO dbo.TB_ADDRESS(id,id_custumer,id_status_address,state,city,district,address,code) 
VALUES
('e6cb18a1-258a-4d28-8de1-b4029a34b3c6','38e4a1b2-130e-4f6f-a587-a0ea91e8c929','12b24eb4-4c25-4c2c-86e6-0252d5bc4853',
 'SP','SÃO PAULO','CENTRO','Av. São João, 439','01035-000'
)
    



