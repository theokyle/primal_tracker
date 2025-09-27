
function ResourceItem({item}) {
    return (
        <div>
            <div>{item.name}</div>
            <div>{item.icon}</div>
            <div>{item.amount}</div>
        </div>
    )
}

export default ResourceItem;