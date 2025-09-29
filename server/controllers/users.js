import { Router } from "express";
import { catchAsync, AppError } from "../middleware/errors";
import User from "../models/User";
import passport from "passport";

const router = Router();

// POST - Create a New User
router.post("/register", catchAsync( async (req, res) => {
    const user = new User({ email: req.body.email });
    await User.register(user, req.body.password);
    res.json({ success: true});
}))

// POST - Login a User
router.post("/login", passport.authenticate("local"), (req, res) => {
    res.json({ user: req.user });
})

// POST - Logout a User
router.post("/logout", catchAsync(async (req, res, next) => {
    if (!req.user) throw new AppError("Not logged in", 401);
    await req.logout();
    res.json({ success: true})
}))

// GET - Get information on logged in user
router.get("/current", (req, res) => {
    res.json({ user: req.user || null });
} )

export default router;