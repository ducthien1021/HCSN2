import axios from "axios";

// https://www.youtube.com/watch?v=ZcdJcZgf_94: SET UP AXIOS CHO FRONTEND
const axiosClient = axios.create({
    baseURL: "https://localhost:7068/api",
    headers: {
        "Content-Type": "application/json"
    }
});

export default axiosClient;