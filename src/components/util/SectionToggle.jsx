
function SectionToggle({tabs, active, onChange}) {
    return(
        <div className="inline-flex rounded-lg shadow-md overflow-hidden bg-white mx-auto">
            {tabs.map(tab => (
                <button key={tab}
                className={`p-2 text-sm font-medium transition-colors ${active === tab ? "bg-blue-500 text-white" : "bg-gray-200 text-gray-700 hover:bg-gray-300"}`} onClick={() => onChange(tab)}>{tab}</button>
            ))}
        </div>
    )
}

export default SectionToggle;