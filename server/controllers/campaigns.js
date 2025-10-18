import { Router } from "express";
import { catchAsync, AppError} from "../middleware/errors.js";
import Campaign from "../models/Campaign.js";
import { authenticateUser } from "../middleware/auth.js";

const router = Router();
router.use(authenticateUser);

// POST - Create a campaign
router.post("/", catchAsync( async (req, res) => {
    const campaign = new Campaign({ user: req.user });
    await campaign.save;
    res.status(201).json(campaign);
}))

// GET - Get all campaigns
router.get("/", catchAsync( async (req, res) => {
    const campaigns = await Campaign.find({ user: req.user });
    res.json(campaigns);
}))

// GET - Get details on a particular campaign
router.get("/:id", async (req, res) => {
    const campaign = await Campaign.findById(req.params.id);

    if (!campaign) {
        throw new AppError ("Campaign not found", 404)
    }

    if (!campaign.user.equals(req.user._id)) {
        throw new AppError("User not authorized for this campaign", 403)
    }

    res.json(campaign);
});

// PATCH - Update a Campaign
// router.patch("/:id", (req, res) => {
//     const campaign = req.body.campaign;

    
// })

// DELETE - Delete a campaign
// router.delete("/:id")

export default router;