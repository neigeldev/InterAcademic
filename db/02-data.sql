INSERT INTO
    teacher (name, email)
VALUES (
        'Professor Smith',
        'smith@nexus.com'
    ),
    (
        'Professor Johnson',
        'johnson@nexus.com'
    ),
    (
        'Professor Williams',
        'williams@nexus.com'
    ),
    (
        'Professor Brown',
        'brown@nexus.com'
    ),
    (
        'Professor Davis',
        'davis@nexus.com'
    );

INSERT INTO
    course (
        fk_teacher_id,
        course_name,
        credits
    )
VALUES (1, 'Mathematics I', 3),
    (1, 'Mathematics II', 3),
    (2, 'Physics I', 3),
    (2, 'Physics II', 3),
    (3, 'Programming I', 3),
    (3, 'Programming II', 3),
    (4, 'Databases I', 3),
    (4, 'Databases II', 3),
    (5, 'Networks I', 3),
    (5, 'Networks II', 3);
