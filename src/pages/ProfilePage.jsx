import Topbar from "../components/layout/Topbar";
import { UserContext } from "../context/UserContext";
import { useState, useContext } from "react";
import { useNavigate } from "react-router";

export default function ProfilePage() {
    const {login, error} = useContext(UserContext)
    const [form, setForm] = useState({ email: "", password: ""})
    const [localError, setLocalError] = useState(null);
    const [submitting, setSubmitting] = useState(null);
    let navigate = useNavigate();

    const handleChange = e => {
        setForm({
            ...form,
            [e.target.name]: e.target.value
        });
    }

    const handleSubmit = async (e) => {
    e.preventDefault();
    setLocalError(null);
    setSubmitting(true);

    if (!form.email || !form.password) {
      setLocalError("Please enter both email and password.");
      setSubmitting(false);
      return;
    }

    try {
      await login(form.email, form.password);
      navigate("/");
    } catch (err) {
      setLocalError(err.message || "Login failed.");
    } finally {
      setSubmitting(false);
    }
  };

    return (
        <main className='flex-1 bg-gray-100'>
            <div className="flex items-center justify-center h-screen bg-background">
                <div className="w-full max-w-md p-8 bg-white shadow-lg rounded-2xl">
                    <h1 className="text-2xl font-bold mb-6 text-center">Sign In</h1>

                    {(localError || error) && (
                    <div className="mb-4 text-red-600 text-sm text-center">
                        {localError || error}
                    </div>
                    )}

                    <form onSubmit={handleSubmit} className="space-y-4">
                    <div>
                        <label htmlFor="email" className="block text-sm font-medium mb-1">
                        Email
                        </label>
                        <input
                        type="email"
                        name="email"
                        id="email"
                        value={form.email}
                        onChange={handleChange}
                        className="w-full p-2 border rounded-md focus:outline-none focus:ring focus:ring-primary"
                        placeholder="you@example.com"
                        />
                    </div>

                    <div>
                        <label
                        htmlFor="password"
                        className="block text-sm font-medium mb-1"
                        >
                        Password
                        </label>
                        <input
                        type="password"
                        name="password"
                        id="password"
                        value={form.password}
                        onChange={handleChange}
                        className="w-full p-2 border rounded-md focus:outline-none focus:ring focus:ring-primary"
                        />
                    </div>

                    <button
                        type="submit"
                        disabled={submitting}
                        className="w-full py-2 bg-primary text-primary-foreground font-semibold rounded-md hover:opacity-90 transition disabled:opacity-50"
                    >
                        {submitting ? "Signing in..." : "Sign In"}
                    </button>
                    </form>

                    <p className="text-sm text-center mt-4">
                    Don’t have an account?{" "}
                    <a href="/signup" className="text-primary hover:underline">
                        Sign up
                    </a>
                    </p>
                </div>
                </div>
        </main>
    )
}