function showTab(name) {
    document.querySelectorAll('.section').forEach(s => s.classList.remove('active'));
    document.querySelectorAll('.tab').forEach(t => t.classList.remove('active'));
    document.getElementById(name).classList.add('active');
    event.target.classList.add('active');
}

async function loadStudents() {
    const res = await fetch('/students');
    const data = await res.json();
    document.querySelector('#studentsTable tbody').innerHTML = data.map(s =>
        `<tr><td>${s.id}</td><td>${s.firstName}</td><td>${s.lastName}</td><td>${s.age}</td><td>${s.groupId}</td></tr>`
    ).join('');
}

async function addStudent() {
    const body = {
        firstName: document.getElementById('s_fn').value,
        lastName: document.getElementById('s_ln').value,
        age: +document.getElementById('s_age').value,
        groupId: +document.getElementById('s_gid').value
    };
    await fetch('/students', { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(body) });
    loadStudents();
}

async function updateStudent() {
    const id = document.getElementById('s_upd_id').value;
    const body = {
        firstName: document.getElementById('s_upd_fn').value,
        lastName: '', age: 0, groupId: 0
    };
    await fetch(`/students/${id}`, { method: 'PUT', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(body) });
    loadStudents();
}

async function deleteStudent() {
    const id = document.getElementById('s_del_id').value;
    await fetch(`/students/${id}`, { method: 'DELETE' });
    loadStudents();
}

async function loadGroups() {
    const res = await fetch('/groups');
    const data = await res.json();
    document.querySelector('#groupsTable tbody').innerHTML = data.map(g =>
        `<tr><td>${g.id}</td><td>${g.name}</td></tr>`
    ).join('');
}

async function addGroup() {
    const body = { name: document.getElementById('g_name').value };
    await fetch('/groups', { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(body) });
    loadGroups();
}

async function updateGroup() {
    const id = document.getElementById('g_upd_id').value;
    const body = { name: document.getElementById('g_upd_name').value };
    await fetch(`/groups/${id}`, { method: 'PUT', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(body) });
    loadGroups();
}

async function deleteGroup() {
    const id = document.getElementById('g_del_id').value;
    await fetch(`/groups/${id}`, { method: 'DELETE' });
    loadGroups();
}

async function loadSubjects() {
    const res = await fetch('/subjects');
    const data = await res.json();
    document.querySelector('#subjectsTable tbody').innerHTML = data.map(s =>
        `<tr><td>${s.id}</td><td>${s.name}</td></tr>`
    ).join('');
}

async function addSubject() {
    const body = { name: document.getElementById('sub_name').value };
    await fetch('/subjects', { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(body) });
    loadSubjects();
}

async function updateSubject() {
    const id = document.getElementById('sub_upd_id').value;
    const body = { name: document.getElementById('sub_upd_name').value };
    await fetch(`/subjects/${id}`, { method: 'PUT', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(body) });
    loadSubjects();
}

async function deleteSubject() {
    const id = document.getElementById('sub_del_id').value;
    await fetch(`/subjects/${id}`, { method: 'DELETE' });
    loadSubjects();
}

async function loadTeachers() {
    const res = await fetch('/teachers');
    const data = await res.json();
    document.querySelector('#teachersTable tbody').innerHTML = data.map(t =>
        `<tr><td>${t.id}</td><td>${t.name}</td></tr>`
    ).join('');
}

async function addTeacher() {
    const body = { name: document.getElementById('t_name').value };
    await fetch('/teachers', { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(body) });
    loadTeachers();
}

async function updateTeacher() {
    const id = document.getElementById('t_upd_id').value;
    const body = { name: document.getElementById('t_upd_name').value };
    await fetch(`/teachers/${id}`, { method: 'PUT', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(body) });
    loadTeachers();
}

async function deleteTeacher() {
    const id = document.getElementById('t_del_id').value;
    await fetch(`/teachers/${id}`, { method: 'DELETE' });
    loadTeachers();
}

async function loadGrades() {
    const res = await fetch('/grades');
    const data = await res.json();
    document.querySelector('#gradesTable tbody').innerHTML = data.map(g =>
        `<tr><td>${g.id}</td><td>${g.studentId}</td><td>${g.subjectId}</td><td>${g.gradeValue}</td></tr>`
    ).join('');
}

async function addGrade() {
    const body = {
        studentId: +document.getElementById('gr_sid').value,
        subjectId: +document.getElementById('gr_subid').value,
        gradeValue: +document.getElementById('gr_val').value
    };
    await fetch('/grades', { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(body) });
    loadGrades();
}

async function updateGrade() {
    const id = document.getElementById('gr_upd_id').value;
    const body = { studentId: 0, subjectId: 0, gradeValue: +document.getElementById('gr_upd_val').value };
    await fetch(`/grades/${id}`, { method: 'PUT', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(body) });
    loadGrades();
}

async function deleteGrade() {
    const id = document.getElementById('gr_del_id').value;
    await fetch(`/grades/${id}`, { method: 'DELETE' });
    loadGrades();
}

loadStudents();