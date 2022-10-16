import React from "react";
import {useQuery} from "@apollo/client";
import {GetAllStudentsData} from "../types";
import {GET_ALL_STUDENTS} from "../queries";
import StudentCard from "./studentCard";

const StudentGrid = () => {
    const { data } = useQuery<GetAllStudentsData>(GET_ALL_STUDENTS);
    return (
        <ul role="list" className="grid grid-cols-1 gap-6 sm:grid-cols-2 lg:grid-cols-3">

            {
                data && data.students.map(student => <StudentCard key={student.id} student={student} />)
            }
        </ul>
    );
};

export default StudentGrid;
