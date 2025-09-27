import ResourceCard from "./ResourceCard";

function PlayerDashboard() {
    const resources = [{
            name: "Materials",
            items: [{
                name: "Scales",
                icon: "",
                amount: 0
            },
            {
                name: "Bones",
                icon: "",
                amount: 2
            }]
        },
        {
            name: "Plants",
            items: [
                {
                    name: "Nillea",
                    icon: "",
                    amount: 0
                },
                {
                    name: "Tarmaret",
                    icon: "",
                    amount: 0
                }
            ]
        }
]

    return (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 p-4 gap-4">
        {resources.map(resource => <ResourceCard key={resource.name} resource={resource}/>)}
        </div>
    )
}

export default PlayerDashboard