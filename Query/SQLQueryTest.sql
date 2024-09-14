CREATE DATABASE BPKB_DEV;

USE BPKB_DEV;

-- Id harusnya menggunakan GUID
CREATE TABLE ms_storage_location (
location_id varchar(10),
location_name varchar(100),
PRIMARY KEY (location_id)
);

CREATE TABLE tr_bpkb (
agreement_number varchar(100) NOT NULL,
bpkb_no varchar(100),
branch_id varchar(10),
bpkb_date datetime,
faktur_no varchar(100),
faktur_date datetime,
location_id varchar(10) FOREIGN KEY REFERENCES ms_storage_location(location_id),
police_no varchar(20),
bpkb_date_in datetime,
created_by varchar(20),
created_on datetime,
last_updated_by varchar(20),
last_updated_on datetime,
PRIMARY KEY (agreement_number)
);

CREATE TABLE ms_user (
user_id bigint,
user_name varchar(20),
password varchar(50),
is_active bit,
PRIMARY KEY (user_id)
);

--Agar kolom password cukup untuk di enkripsi
ALTER TABLE ms_user
ALTER COLUMN password varchar(255);

INSERT INTO ms_storage_location
VALUES 
('115', 'Jakarta'),
('145', 'Ciputat'),
('175', 'Pandeglang'),
('190', 'Bekasi');

INSERT INTO tr_bpkb
VALUES 
('1151500001', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '115', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500002', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '115', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500003', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '145', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500004', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '115', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500005', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '145', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500006', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '115', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500007', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '145', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500008', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '115', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500009', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '145', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500010', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '145', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500011', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '115', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500012', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '145', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500013', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '115', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500014', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '115', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500015', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '115', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500016', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '115', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500017', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '175', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500018', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '175', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500019', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '175', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500020', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '175', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),
('1151500021', '1151500002', '1151503', GETDATE(), '343213', GETDATE(), '175', 'B 1 RI', GETDATE(), 'Admin', GETDATE(), 'Admin', GETDATE()),

