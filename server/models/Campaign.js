import mongoose from "mongoose";

const questIds = Array.from({ length: 50 }, (_, i) => `quest_${i + 1}`);

const campaignSchema = new mongoose.Schema({
    user: { type: mongoose.Schema.Types.ObjectId, ref: "User", required: true},

    chapter: { type: Number, default: 1, min: 1, max: 11},

    herbalist: { type: Number, default: 1, min: 1, max: 3},

    forge: { type: Number, default: 1, min: 1, max: 3},

    elements: {
    fire: {type: Boolean, default: false},
    horn: {type: Boolean, default: false},
    coral: {type: Boolean, default: false},
    crystal: {type: Boolean, default: false},
    thunder: {type: Boolean, default: false},
    metal: {type: Boolean, default: false},
    feather: {type: Boolean, default: false},
    venom: {type: Boolean, default: false},
    ice: {type: Boolean, default: false}
    },

    trophies: {
    vyraxen: { type: Boolean, default: false},
    toramat: { type: Boolean, default: false},
    korowon: { type: Boolean, default: false},
    felaxir: { type: Boolean, default: false},
    ozew: { type: Boolean, default: false},
    hurom: { type: Boolean, default: false},
    hydar: { type: Boolean, default: false},
    sirkaaj: { type: Boolean, default: false},
    pazis: { type: Boolean, default: false},
    zekath: { type: Boolean, default: false},
    taraska: { type: Boolean, default: false},
    kharia: { type: Boolean, default: false},
    dygorax: { type: Boolean, default: false},
    orouxen: { type: Boolean, default: false},
    morkraas: { type: Boolean, default: false},
    jekoros: { type: Boolean, default: false},
    tarragua: { type: Boolean, default: false},
    reikal: { type: Boolean, default: false},
    mamuraak: { type: Boolean, default: false},
    nagarias: { type: Boolean, default: false},
    zekalith: { type: Boolean, default: false},
    xitheros: { type: Boolean, default: false}
    },

    quests: { type: Map, of: { type: String, enum: ["locked", "unlocked", "completed", "expired"]}, default: function () {
        const map = {};
        questIds.forEach(id => {
            map[id] = "locked"
        })
        return map;
    }},

    achievements: [String],

    players: [{ type: mongoose.Schema.Types.ObjectId, ref: "Player" }]
})

const Campaign = mongoose.model("Campaign", campaignSchema);

export default Campaign;