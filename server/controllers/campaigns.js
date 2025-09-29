import { Router } from "express";

const router = Router();

// POST - Create a campaign
router.post("/")

// GET - Get all campaigns
router.get("/")

// GET - Get details on a particular campaign
router.get("/:id")

// PUT - Update a Campaign
router.put("/:id")

// DELETE - Delete a campaign
router.delete("/:id")

export default router;