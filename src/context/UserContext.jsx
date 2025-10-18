import { createContext, useEffect, useState } from "react";
import api from "../api/api.js";

export const UserContext = createContext();

export function UserProvider({children}) {
    const [user, setUser] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError ] = useState(null);

    useEffect(() => {
        api.get("/users/current")
        .then(res => setUser(res.data.user))
        .catch(err => setError(err.message))
        .finally(() => setLoading(false));
    }, []);

    const login = (email, password) => {
        api.post("/users/login", {email, password})
        .then(res => setUser(res.data.user))
        .catch(err => setError(err.message))
    }

    const logout = () => {
        api.post("/users/logout")
        .then(() => setUser(null))
        .catch(err => setError(err.message))
    }

    const value = {
        user,
        loading,
        error,
        login,
        logout
    }

    return (
        <UserContext.Provider value={value}>
            {children}
        </UserContext.Provider>
    )
}