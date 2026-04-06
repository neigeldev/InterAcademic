CREATE DATABASE IF NOT EXISTS interacademic CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;

USE interacademic;

-- =========================
-- TABLE: teachers
-- =========================
CREATE TABLE IF NOT EXISTS teacher (
    pk_teacher_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(150) NOT NULL UNIQUE
);

-- =========================
-- TABLE: students
-- =========================
CREATE TABLE IF NOT EXISTS student (
    pk_student_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(150) NOT NULL UNIQUE
);

-- =========================
-- TABLE: courses
-- =========================
CREATE TABLE IF NOT EXISTS course (
    pk_course_id INT AUTO_INCREMENT PRIMARY KEY,
    fk_teacher_id INT NOT NULL,
    course_name VARCHAR(150) NOT NULL,
    credits INT NOT NULL,
    CONSTRAINT fk_course_teacher FOREIGN KEY (fk_teacher_id) REFERENCES teacher (pk_teacher_id) ON DELETE RESTRICT ON UPDATE CASCADE
);

-- =========================
-- TABLE: enrollments
-- =========================
CREATE TABLE IF NOT EXISTS enrollment (
    fk_student_id INT NOT NULL,
    fk_course_id INT NOT NULL,
    enrolled_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (fk_student_id, fk_course_id),
    CONSTRAINT fk_enrollment_student FOREIGN KEY (fk_student_id) REFERENCES student (pk_student_id) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT fk_enrollment_course FOREIGN KEY (fk_course_id) REFERENCES course (pk_course_id) ON DELETE CASCADE ON UPDATE CASCADE
);
