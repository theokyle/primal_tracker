import ResourceItem from "./ResourceItem";

function ResourceCard({resource}) {
    console.log("resource:", resource);
    return (
        <div className="bg-white p-6 shadow-lg rounded-lg">
            <h2 className="text-xl font-bold">{resource.name}</h2>
            {resource.items.map(item => <ResourceItem key={item.name} item={item} />)}
          </div>
    )
}

export default ResourceCard;