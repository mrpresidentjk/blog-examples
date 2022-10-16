import React from 'react';
import {BrowserRouter as Router, Route, Routes} from "react-router-dom";
import Students from "./features/enrollments/pages/students";
import Student from "./features/enrollments/pages/student";


function App() {
  return (
      <div className="p-20">
          <Router>
              <Routes>
                  <Route index element={<Students/>}/>
                  <Route path={":id"} element={<Student/>}/>
              </Routes>
          </Router>
      </div>
  );
}

export default App;
