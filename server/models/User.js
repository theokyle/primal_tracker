import mongoose from "mongoose";

const userSchema = new mongoose.Schema({
    username: { type: String, required: true, unique: true},
    email: { type: String, required: true, unique: true},
    passwordHash: { type: String, required: true},
    activeCampaign: { type: mongoose.Schema.Types.ObjectId, ref: "Campaign"}
},
{ timestamps: true})

const User = mongoose.model("User", userSchema);

export default User;