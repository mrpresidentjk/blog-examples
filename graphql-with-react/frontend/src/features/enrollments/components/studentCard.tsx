import { Link } from "react-router-dom";
import {StudentItem} from "../types";


interface OwnProps {
    student: StudentItem
}

const StudentCard = ({student}: OwnProps) => {
    const initials = (student.firstName.charAt(0) + student.lastName.charAt(0)).toUpperCase()
    return (
        <li className="col-span-1 divide-y divide-gray-200 rounded-lg bg-white hover:bg-gray-100 shadow">
            <Link to={`/${student.id}`}>
                <div className="flex w-full items-center justify-between space-x-6 p-6">
                    <div className="flex-1 truncate">
                        <div className="flex items-center space-x-3">
                            <h3 className="truncate text-sm font-medium text-gray-900">{student.firstName} {student.lastName}</h3>
                        </div>
                    </div>
                    <span className="inline-flex h-14 w-14 items-center justify-center rounded-full bg-gray-500">
                        <span className="text-xl font-medium leading-none text-white">{initials}</span>
                    </span>
                </div>
            </Link>
        </li>
    );
}

export default StudentCard;
