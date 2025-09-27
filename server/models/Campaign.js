import mongoose from "mongoose";

const defaultElements = {
    fire: 0,
    horn: 0,
    coral: 0,
    crystal: 0,
    thunder: 0,
    metal: 0,
    feather: 0,
    venom: 0,
    ice: 0
};

const defaultTrophies = {
    vyraxen: false,
    toramat: false,
    korowon: false,
    felaxir: false,
    ozew: false,
    hurom: false,
    hydar: false,
    sirkaaj: false,
    pazis: false,
    zekath: false,
    taraska: false,
    kharia: false,
    dygorax: false,
    orouxen: false,
    morkraas: false,
    jekoros: false,
    tarragua: false,
    reikal: false,
    mamuraak: false,
    nagarias: false,
    zekalith: false,
    xitheros: false
}

const questIds = Array.from({ length: 50 }, (_, i) => `quest_${i + 1}`);

const campaignSchema = new mongoose.Schema({
    user: { type: mongoose.Schema.Types.ObjectId, ref: "User", required: true},

    chapter: { type: Number, default: 1, min: 1, max: 11},

    herbalist: { type: Number, default: 1, min: 1, max: 3},

    forge: { type: Number, default: 1, min: 1, max: 3},

    elements: { type: Map, of: Boolean, default: defaultElements},

    trophies: { type: Map, of: Boolean, default: defaultTrophies},

    quests: { type: Map, of: { type: String, enum: ["locked", "unlocked", "completed", "expired"]}, default: function () {
        const map = {};
        questIds.forEach(id => {
            map[id] = "locked"
        })
    }},

    achievements: [String]
})

const Campaign = mongoose.model("Campaign", campaignSchema);

export default Campaign;