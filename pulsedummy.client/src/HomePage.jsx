import { useState, useEffect } from "react";
import {FaSearch, FaSync, FaEdit, FaTrash, FaSort } from "react-icons/fa";
import Select from 'react-select';
import { AgGridReact } from "ag-grid-react";
import { ModuleRegistry, AllCommunityModule } from 'ag-grid-community';
// import "ag-grid-community/styles/ag-grid.css";
// import "ag-grid-community/styles/ag-theme-alpine.css";
import "./index.css";

// Register AG Grid modules
ModuleRegistry.registerModules([AllCommunityModule]);
export default function HomePage(){
    const [rowData, setRowData] = useState([
    { name: "John Doe", email: "john@example.com", department: "Admin" },
    { name: "Sara Smith", email: "sara@example.com", department: "User" },
    { name: "Alex Johnson", email: "alex@example.com", department: "Manager" },
  ]);

  const CustomHeader = (props) => {
  return (
    <div className="flex items-center gap-2">
      <span>{props.displayName}</span>
      <FaSort  />
    </div>
  );
};
  const columnDefs = [
    { field: "name", headerName: "Name", sortable: true, flex:1, headerClass: "my-header-class", headerComponent: CustomHeader,}, 
    { field: "email", headerName: "Email", sortable: true, flex:1, headerClass: "my-header-class", headerComponent: CustomHeader, },
    { field: "department", headerName: "Department", sortable: true, flex:1, headerClass: "my-header-class", headerComponent: CustomHeader, },
    {
        headerName: "",
        field: "edit",
        headerClass: "my-header-class",
        cellRenderer: (params) => (
          <button className="cursor-pointer active:bg-purple-300 active:scale-95 transition py-2 px-3">
            <FaEdit size={25} /> 
          </button>
    ),
    width: 50,
    suppressHeaderMenuButton: true,
    sortable: true,
    cellStyle: { padding: 0, display: "flex", alignItems: "center", justifyContent: "center", }
},

{
        headerName: "",
        field: "delete",
        headerClass: "my-header-class",
        cellRenderer: (params) => (
          <button className="cursor-pointer active:bg-red-300 active:scale-95 transition py-2 px-3">
            <FaTrash  size={25} color="red"/> 
          </button>
    ),
    width: 50,
    suppressHeaderMenuButton: true,
    sortable: true,
    cellStyle: { padding: 0, display: "flex", alignItems: "center", justifyContent: "center" }
}
  ];

  useEffect(()=>{
    const getUsers = async ()=>{
    const response = await fetch("https://localhost:7251/api/user/getUserData", {
        method: "GET",
        headers: {
                    "Content-Type": "application/json"
            },
    });

    console.log("response is ", response)
    console.log("response text is", await response.text())
};
 
getUsers();
  },[])

    return (
        <div className="w-full p-8">
            {/* Top row: Search, Department, Sync */}
            <div className="flex items-end gap-4 w-full mb-4">
                {/* Search */}
                <div className="flex-1">
                    <label className="block mb-1 font-semibold" htmlFor="searchInput">Search</label>
                    <div className="flex items-center border border-gray-300 rounded px-2">
                        <input
                            id="searchInput"
                            placeholder="Search Employees"
                            className="flex-1 p-1.5 bg-transparent outline-none"
                        />
                        <FaSearch className="text-gray-500" />
                    </div>
                </div>

                {/* Department */}
                <div className="flex-1">
                    <label className="block mb-1 font-semibold">Department</label>
                    <Select placeholder="Please Select" className="w-full" />
                </div>

                {/* Sync Icon */}
                <div className="mb-1">
                    <FaSync className="text-3xl p-1 text-gray-600 cursor-pointer active:bg-gray-300 active:scale-95 transition" />
                </div>
            </div>

            {/* AG Grid - on a new line */}
            <div className="ag-theme-quartz">
                <AgGridReact
                    rowData={rowData}
                    columnDefs={columnDefs}
                    domLayout="autoHeight"
                />
            </div>
        </div>
    )
}