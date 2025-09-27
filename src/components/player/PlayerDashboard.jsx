import { useState } from "react";
import ResourceCard from "./ResourceCard";
import SectionToggle from "../util/SectionToggle";
import SkillCard from "./SkillCard";

function PlayerDashboard() {
    const [section, setSection] = useState("Resources");
    const tabs = ["Resources", "Skills", "Equipment"];
    
    return (
        <div className="flex flex-col justify-center p-6">
            <SectionToggle tabs={tabs} active={section} onChange={setSection} />
            {section === "Resources" &&
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 p-4 gap-4">
                <ResourceCard type="materials" />
                <ResourceCard type="plants" />
                <ResourceCard type="elements" />
             </div>
            }
            {section === "Skills" &&
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 p-4 gap-4">
                <SkillCard />
             </div>
            }
        </div>
    )
}

export default PlayerDashboard;