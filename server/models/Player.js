import mongoose from "mongoose";

const defaultMaterials = {
    scales: 0,
    bones: 0,
    blood: 0,
    zima: 0,
    iride: 0,
    kobaureo: 0
};

const defaultPlants = {
    nillea: 0,
    tarmaret: 0,
    albalacea: 0,
    millis: 0,
    anthemon: 0,
    saelicornia: 0
};

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
}

const defaultSkills = {
    a1: false,
    a2: false,
    b1: false,
    b2: false,
    c1: false,
    c2: false,
    d1: false,
    d2: false,
    e1: false,
    e2: false
}

const PlayerSchema = new mongoose.Schema({
    user: { type: mongoose.Schema.Types.ObjectId, ref: "User", required: true},

    campaign: {type: mongoose.Schema.Types.ObjectId, ref: "Campaign", required: true},

    name: { type: String, required: true },

    class: { type: String, required: true, enum: ["Dareon", "Thoreg", "Mirah", "Karah", "Heleren", "Ljonar"]},

    materials: {
        type: Map,
        of: Number,
        default: defaultMaterials
    },

    plants: {
        type: Map,
        of: Number,
        default: defaultPlants
    },

    elements: {
        type: Map,
        of: Number,
        default: defaultElements
    },

    skills: {
        type: Map,
        of: Boolean,
        default: defaultSkills
    }
})

const Player = mongoose.model('Player', PlayerSchema);

export default Player;