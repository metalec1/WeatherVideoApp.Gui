using CommunityToolkit.Mvvm.ComponentModel;

namespace WeatherVideoApp.Gui.ViewModels;

public partial class VideoInformationViewModel : ViewModelBase
{
    [ObservableProperty] public partial string VideoInformationText {get; set; }

    public VideoInformationViewModel()
    {
        VideoInformationText =
            "The International Space Station (ISS)[c] is a space station in low Earth orbit (LEO). It is the product of the International " +
            "Space Station program and is operated by five partner space agencies: NASA (United States), Roscosmos (Russia), ESA (Europe), JAXA " +
            "(Japan), and CSA (Canada).[13] It is the first space station built, maintained and crewed through international cooperation and the largest " +
            "human spacecraft ever constructed.[14][15] It is an orbital research station, where scientific experiments in microgravity are conducted and the space " +
            "environment is studied.[15] Since 2 November 2000, it has hosted the longest continuous human presence in space.[16] Alongside China's Tiangong, it is " +
            "one of two currently operational space stations.[17]\n\nThe station orbits between 51.64° north and south, at about 400 kilometres (250 miles)[18] above Earth, " +
            "below the Van Allen radiation belts and most space debris.[19] Its orbit takes it at 7.67 km/s (27,600 km/h; 17,200 mph) roughly every 93 minutes around Earth, " +
            "15.5 times a day.[20] Measuring 109 m (358 ft) (with solar arrays) by 73 m (239 ft),[21] it is as large as a full-sized football or soccer field,[22] and has a " +
            "pressurised internal volume of 1,005 m3 (35,491 ft3), comparable to a Boeing 747 airliner.[21]\n\nThe station is a modular space station divided into two main " +
            "sections: the Russian Orbital Segment (ROS), developed by Roscosmos, and the US Orbital Segment (USOS), built by NASA, ESA, JAXA, and CSA. The Integrated Truss " +
            "Structure connects the station's vast system of solar panels and radiators to its 16 major pressurized modules. These modules support scientific research, crew " +
            "habitation, storage, spacecraft control, and airlock operations. The ISS has eight docking and berthing ports for visiting spacecraft. In total, the station " +
            "consists of 43 different modules and elements.[23] Crews visit via the Soyuz and Crew Dragon spacecraft, and previously the Space Shuttle.[d] Cargo supply craft " +
            "include Progress, Cargo Dragon, Cygnus, Automated Transfer Vehicle, and HTV-X. The ISS is the political product of the development of international cooperation " +
            "in space throughout the space age. The station combines two previously planned crewed Earth-orbiting stations: the United States' Space Station Freedom and the " +
            "Soviet Union's Mir-2. The first ISS module was launched in 1998, with major components delivered by Proton, Soyuz and Space Shuttle launch vehicles. Long-term " +
            "occupancy began with the arrival of the Expedition 1 crew on 2 November 2000. Since then, the ISS has remained continuously inhabited for 25 years and 319 days, " +
            "the longest continuous human presence in space. As of August 2025, 290 individuals from 26 countries had visited the station.[24]\n\nFuture plans for the ISS " +
            "include the addition of at least one module, the Payload Power Thermal Module by Axiom Space, forming the commercial segment of the station. The station is " +
            "expected to remain operational until the end of 2030, by which parts of it are to be used for Axiom Station and the Russian Orbital Service Station. After this " +
            "the ISS is planned to be de-orbited using the US Deorbit Vehicle,[25] but critique of this plan and the proposal of parking the station at a more stable higher " +
            "orbit has gathered congressional support as of 2026. Early into the space age and ensuing space race the US and USSR began to find opportunities for potential " +
            "collaborations in outer space. This culminated in the 1975 Apollo–Soyuz Test Project, the first docking of spacecraft from two different spacefaring nations. " +
            "The ASTP was considered a success, and further joint missions were also contemplated.\n\nOne such concept was International Skylab, which proposed launching " +
            "the backup Skylab B space station for a mission that would see multiple visits by both Apollo and Soyuz crew vehicles.[26] More ambitious was the Skylab-Salyut " +
            "Space Laboratory, which proposed docking the Skylab B to a Soviet Salyut space station. Falling budgets and rising Cold War tensions in the late 1970s saw these " +
            "concepts fall by the wayside, along with another plan to have the Space Shuttle dock with a Salyut space station.[27]\n\nIn the early 1980s, NASA planned to " +
            "launch a modular space station called Freedom as a counterpart to the Salyut and Mir space stations. In 1984 the European Space Agency (ESA) was invited to" +
            " participate in Space Station Freedom, and the ESA approved the Columbus laboratory by 1987.[28] The Japanese Experiment Module (JEM), or Kibō, was announced " +
            "in 1985, as part of the Freedom space station in response to a NASA request in 1982.\n\nIn early 1985, science ministers from the ESA countries approved the " +
            "Columbus program, the most ambitious effort in space undertaken by that organization at the time. The plan spearheaded by Germany and Italy included a module" +
            " which would be attached to Freedom, and with the capability to evolve into a full-fledged European orbital outpost before the end of the century.[29]\n\nIncreasing " +
            "costs threw these plans into doubt in the early 1990s. Congress was unwilling to provide enough money to build and operate Freedom, and demanded NASA increase " +
            "international participation to defray the rising costs or they would cancel the entire project outright.[30]\n\nSimultaneously, the USSR was conducting " +
            "planning for the Mir-2 space station, and had begun constructing modules for the new station by the mid-1980s. However the collapse of the Soviet Union " +
            "required these plans to be greatly downscaled, and soon Mir-2 was in danger of never being launched at all.[31] With both space station projects in " +
            "jeopardy, American and Russian officials met and proposed they be combined.[32]\n\nIn September 1993, American Vice-President Al Gore and Russian Prime Minister " +
            "Viktor Chernomyrdin announced plans for a new space station, which eventually became the International Space Station.[33] They also agreed, in preparation " +
            "for this new project, that the United States would be involved in the Mir program, including American Shuttles docking, in the Shuttle–Mir program.";
    }

}