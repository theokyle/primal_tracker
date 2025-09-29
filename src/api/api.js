import axios from "axios";

const api = axios.create({
    baseURL: process.env.PT_API,
    withCredentials: true
})

export default api;