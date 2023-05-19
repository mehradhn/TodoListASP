import React from "react";

function Table() {
  return (
    <>
      <table className="bg-gray-800 text-white border border-white">
        <thead>
          <tr>
            <th className="px-4 py-2 border-b">PostId</th>
            <th className="px-4 py-2 border-b">Title</th>
            <th className="px-4 py-2 border-b">Content</th>
            <th className="px-4 py-2 border-b">CRUD Operations</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td className="px-4 py-2 border-b border-l text-center">1</td>
            <td className="px-4 py-2 border-b border-l">Title 1</td>
            <td className="px-4 py-2 border-b border-l">Content 1</td>
            <td className="px-4 py-2 border-b border-l">
              <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded mr-2">
                Update
              </button>
              <button className="bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded">
                Delete
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </>
  );
}

export default Table;
