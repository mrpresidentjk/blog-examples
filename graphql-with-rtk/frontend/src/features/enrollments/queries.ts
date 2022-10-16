import {gql} from '@apollo/client';

export const GET_ALL_STUDENTS = gql`
query GetStudents {
    students {
      id
      firstName
      lastName
    }
}
`;

export const GET_STUDENT_BY_ID = gql`
query GetStudentById($id: Int!) {
  student(id: $id) {
    id
    firstName
    lastName
    courses {
      id
      title
    }
  }
}
`;
