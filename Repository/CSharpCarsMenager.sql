CREATE DATABASE CSharpCarsManager;

USE CSharpCarsManager;

CREATE TABLE cars (
    IdCar INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    BrandCar VARCHAR(255) NOT NULL,
    ModelCar VARCHAR(255) NOT NULL,
    YearCar YEAR NOT NULL,
    ColorCar VARCHAR(255) NOT NULL,
    LicensePlateCar VARCHAR(10) NOT NULL,
    TypeCar VARCHAR(255) NOT NULL,
    PriceCar DECIMAL(10,2) NOT NULL
);
select * from cars;
