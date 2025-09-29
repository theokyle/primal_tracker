import express from "express";
import mongoose from "mongoose";
import dotenv from "dotenv";
import cors from "cors";
import passport from "passport";
import LocalStrategy from "passport-local";
import User from "./models/User.js";
import session from "express-session";

import campaigns from "./controllers/campaigns.js";
import players from "./controllers/players.js";
import users from "./controllers/users.js";

dotenv.config();

const app = express();
const port = 3000;

app.use(express.json());
app.use(cors({
  origin: process.env.PT_API,
  credentials: true,
}));

app.use(session({
  secret: process.env.SESSION_SECRET,
  resave: false,
  saveUninitialized: false
}));

app.use(passport.initialize());
app.use(passport.session());

passport.use(User.createStrategy());
passport.serializeUser(User.serializeUser());
passport.deserializeUser(User.deserializeUser());

mongoose.connect(process.env.MONGODB);
const db = mongoose.connection;

db.on("error", console.error.bind(console, "Connection Error:"));
db.once(
  "open",
  console.log.bind(console, "Successfully opened connection to Mongo!")
);

app.get("/", (request, response) => {
  response.send("Welcome to the Primal Tracker API");
});
app.get("/status", (request, response) => {
  response.json({ message: "Service healthy" });
});

app.use("/campaign", campaigns);
app.use("/player", players);
app.use("/user", users);

app.use((err, req, res, next) => {
  console.error(err);
  res.status(500).send({ error: err.message })
})

const server = app.listen(port, () => console.log(`Listening on Port: ${server.address().port}`))