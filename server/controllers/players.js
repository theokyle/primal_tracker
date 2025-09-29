import { Router } from "express";

const router = Router();

// POST Create Player
router.post("/")

// GET Get detailed information on a player
router.get("/:id")

// GET Get all players for current campaign
router.get("/campaign")

// PUT Update Resources
router.put("/:id/resources")

// PUT Update Quests
router.put("/:id/quests")

export default router;