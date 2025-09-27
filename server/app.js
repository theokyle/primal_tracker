import express from "express";
import mongoose from "mongoose";
import dotenv from "dotenv";
import cors from "cors";
import { catchAsync } from "./middleware/errors";

dotenv.config();

const app = express();
const port = 3000;

app.use(express.json());
app.use(cors());

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

app.use((err, req, res, next) => {
  console.error(err);
  res.status(500).send({ error: err.message })
})

const server = app.listen(port, () => console.log(`Listening on Port: ${server.address().port}`))