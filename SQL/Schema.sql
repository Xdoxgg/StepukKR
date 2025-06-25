DROP TABLE Users
Drop table Reviews
Drop table Appointments
Drop table Reviews
-- Таблица пользователей
CREATE TABLE Users
(
    user_id  INT PRIMARY KEY IDENTITY (1,1),
    username NVARCHAR(50)  NOT NULL,
    password NVARCHAR(255) NOT NULL,
    role     BIT           NOT NULL
);

-- Таблица врачей
CREATE TABLE Doctors
(
    doctor_id      INT PRIMARY KEY IDENTITY (1,1),
    first_name     NVARCHAR(255) NOT NULL,
    last_name      NVARCHAR(255) NOT NULL,
    specialization NVARCHAR(255) NOT NULL,
    schedule       NVARCHAR(255) NOT NULL
);

-- Таблица услуг
CREATE TABLE Services
(
    service_id   INT PRIMARY KEY IDENTITY (1,1),
    service_name NVARCHAR(255) NOT NULL,
    price        FLOAT         NOT NULL,
    description  NVARCHAR(255)
);

-- Таблица записей
CREATE TABLE Appointments
(
    appointment_id   INT PRIMARY KEY IDENTITY (1,1),
    user_id          INT,
    doctor_id        INT,
    service_id       INT,
    appointment_date DATETIME      NOT NULL,
    status           NVARCHAR(255) NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users (user_id),
    FOREIGN KEY (doctor_id) REFERENCES Doctors (doctor_id),
    FOREIGN KEY (service_id) REFERENCES Services (service_id)
);

-- Таблица отзывов
CREATE TABLE Reviews
(
    review_id  INT PRIMARY KEY IDENTITY (1,1),
    user_id    INT,
    doctor_id  INT,
    rating     INT,
    comment    NVARCHAR(255),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES Users (user_id),
    FOREIGN KEY (doctor_id) REFERENCES Doctors (doctor_id)
);


SELECT * FROM Appointments