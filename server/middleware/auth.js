import { AppError } from "../middleware/errors.js";

export async function authenticateUser(req, res, next) {
    if (!req.user) {
        throw new AppError("Not authenticated", 401);
    }

    next();
}