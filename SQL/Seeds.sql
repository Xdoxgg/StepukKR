-- Сиды для таблицы пользователей
INSERT INTO Users (username, password, role)
VALUES ('user1', 'password1', 0),
       ('user2', 'password2', 0),
       ('admin', 'adminpass', 1);

-- Сиды для таблицы врачей
INSERT INTO Doctors (first_name, last_name, specialization, schedule)
VALUES ('Иван', 'Иванов', 'Терапевт', 'Пн-Пт 9:00-17:00'),
       ('Петр', 'Петров', 'Хирург', 'Пн-Сб 10:00-18:00'),
       ('Светлана', 'Сидорова', 'Педиатр', 'Вт-Чт 8:00-16:00');

-- Сиды для таблицы услуг
INSERT INTO Services (service_name, price, description)
VALUES ('Консультация', 100.00, 'Первичная консультация врача'),
       ('УЗИ', 500.00, 'Ультразвуковое исследование'),
       ('Анализы', 300.00, 'Общий анализ крови и мочи');

-- Сиды для таблицы записей
INSERT INTO Appointments (user_id, doctor_id, service_id, appointment_date, status)
VALUES (1, 1, 1, '25/06/2025 10:00:00', 'Запланировано'),
       (2, 2, 2, '26/06/2025 11:00:00', 'Запланировано');

-- Сиды для таблицы отзывов
INSERT INTO Reviews (user_id, doctor_id, rating, comment)
VALUES (1, 1, 5, 'Отличный врач, все объяснил!'),
       (2, 2, 4, 'Хороший специалист, но долго ждал приема.');
