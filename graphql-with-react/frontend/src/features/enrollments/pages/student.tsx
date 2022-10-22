import {useQuery} from "@apollo/client";
import {GetStudentByIdData, GetStudentByIdVars} from "../types";
import {GET_STUDENT_BY_ID} from "../queries";
import {useParams} from "react-router-dom";
import CourseTable from "../components/courseTable";

const Student = () => {
    const {id} = useParams();
    const {data} = useQuery<GetStudentByIdData, GetStudentByIdVars>(GET_STUDENT_BY_ID, {variables: {id: parseInt(id!)}});
    const courses = data?.student.courses || [];
    return (
        <div className="px-4 sm:px-6 lg:px-8">
            <div className="sm:flex sm:items-center">
                <div className="sm:flex-auto">
                    <h1 className="text-xl font-semibold text-gray-900">{data?.student.firstName} {data?.student.lastName}</h1>
                    <p className="mt-2 text-sm text-gray-700">
                        This student has been enrolled in the following courses.
                    </p>
                </div>
            </div>
            <CourseTable courses={courses}/>
        </div>
    )
};

export default Student;
