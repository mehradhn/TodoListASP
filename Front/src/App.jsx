import React, { useEffect, useState } from "react";
import Table from "./components/Table";

import { useQuery } from "@tanstack/react-query";
function App() {
  const [posts, setPosts] = useState([]);
  const url = "http://localhost:5295/get-all-posts";

  useEffect(() => {
    fetch(url, {
      method: "GET",
    })
      .then((response) => response.json())
      .then((postsFromServer) => {
        setPosts(postsFromServer);
      })
      .catch((error) => {
        console.log("error");
        alert(error);
      });
  }, []);

  // if (allTodos.data) return <h1>Loading...</h1>;

  return (
    <div className="min-h-screen flex justify-center items-center">
      <Table />
    </div>
  );
}

export default App;
