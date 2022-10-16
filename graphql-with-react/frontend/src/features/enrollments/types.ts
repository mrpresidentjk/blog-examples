export interface StudentItem {
    id: number,
    firstName: string;
    lastName: string;
}

export interface Student extends StudentItem {
    courses: Course[]
}

export interface Course {
    id: number;
    title: string;
}

export interface GetAllStudentsData {
    students: StudentItem[]
}

export interface GetStudentByIdData {
    student: Student[]
}

export interface GetStudentByIdVars{
    id: number
}
