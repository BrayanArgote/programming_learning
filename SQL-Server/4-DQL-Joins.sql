-- INNER JOIN
SELECT st.name, st.age, sb.name_subject
FROM Students AS st
INNER JOIN Subjects AS sb ON st.id_subject = sb.id_subject;

-- LEFT JOIN
SELECT st.name, st.age, sb.name_subject
FROM Students AS st
LEFT JOIN Subjects AS sb ON st.id_subject = sb.id_subject