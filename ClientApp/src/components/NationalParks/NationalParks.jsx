import { useEffect } from "react";
import axios from "axios";
import { Box, Flex } from "@chakra-ui/react";
import Loading from "../Loading/Loading";
import {
    useJsApiLoader,
    GoogleMap,
    Marker,
    DirectionsRenderer,
} from "@react-google-maps/api";
import { useState } from "react";
import { Link } from "react-router-dom";
import "../componentStyling.css";

const NPS_API_KEY = process.env.NPS_API_KEY;
const MAP_API_KEY = process.env.REACT_APP_GOOGLE_MAPS_API_KEY;
const YELP_API_KEY = process.env.YELP_API_KEY;
const API_LOADER_DATA = {
    googleMapsApiKey: MAP_API_KEY,
};
const baseUrl = process.env.EXPLORE_API_BASE_ADDRESS;

const NationalParks = () => {
    const [map, setMap] = useState(/** @type google.maps.Map */ (null));
    const [directionsResponse, setDirectionsResponse] = useState(null);
    const [distance, setDistance] = useState("");
    const [duration, setDuration] = useState("");
    const [position, setPosition] = useState({ lat: 0, lng: 0 });
    const [markers, setMarkers] = useState([]);
    const [timingTest, setTimingTest] = useState(false);
    const { isLoaded } = useJsApiLoader(API_LOADER_DATA);
    const factor = 0.621371;
    const [thisDestinationBeer, setThisDestinationBeer] = useState({});
    const [thisDestinationObject, setThisDestinationObject] = useState({});
    const [thisDestinationLatLng, setThisDestinationLatLng] = useState({
        lat: 0,
        lng: 0,
    });
    const [ready, setReady] = useState(false);

    useEffect(() => {
        navigator.geolocation.getCurrentPosition(function (position) {
            let lat = position.coords.latitude;
            let lng = position.coords.longitude;
            // SHOULD BE "position" below
            let myPosition = { lat: lat, lng: lng };
            setPosition(myPosition);
            const config = {
                headers: { "Access-Control-Allow-Origin": true },
            };
            if (!timingTest) {
                axios
                    .get(
                        `http://localhost:5111/api/v1.0/NationalPark?count=5&lat=${myPosition.lat}&lng=${myPosition.lng}&radiusInMiles=1000`,
                        config
                    )
                    .then((e) => {
                        console.log("THIS IS E", e);
                        setThisDestinationObject(e.data[0]);
                        setTimingTest(true);
                    });
            } else {
                calculateRoute();
                if (timingTest && isLoaded) {
                    setReady(true);
                }
            }
        });
    }, [isLoaded, timingTest]);

    async function calculateRoute() {
        if (
            thisDestinationObject === {} ||
            thisDestinationObject === undefined ||
            thisDestinationObject === null
        ) {
            console.log("thisDestinationObject in calculteRoute fuct is bad");
            return;
        }
        // eslint-disable-next-line no-undef
        const directionsService = new google.maps.DirectionsService();
        console.log("INSIDE CALC ROOT", thisDestinationObject);
        const results = await directionsService.route({
            origin: position,
            destination:
                thisDestinationObject.location.lat +
                "," +
                thisDestinationObject.location.lng,
            travelMode: google.maps.TravelMode.DRIVING,
        });
        setDirectionsResponse(results);
        setDistance(results.routes[0].legs[0].distance.text);
        setDuration(results.routes[0].legs[0].duration.text);
    }

    if (!ready || !isLoaded || !timingTest) {
        return <Loading />;
    }
    return (
        <>
            <img class="bg" src="mountains.png" alt="" />
            <Flex
                position="relative"
                flexDirection="column"
                alignItems="left"
                h="75vh"
                w="75vw"
                margin="auto"
            >
                <div className="mapPageHeader ml-0 fixed">
                    <Link to="/">
                        <button className="mt-4">Home</button>
                    </Link>

                    <svg viewBox="0 0 220 30">
                        <text x="37" y="17">
                            Next Stop... Adventure!
                        </text>
                        <text className="tester" x="77" y="27">
                            {thisDestinationObject.name}
                        </text>
                    </svg>
                </div>
                <Box position="absolute" h="100%" w="100%" className="mapBox">
                    {/* Google Map Box */}
                    <GoogleMap
                        center={position}
                        zoom={15}
                        mapContainerStyle={{ width: "100%", height: "100%" }}
                        options={{
                            zoomControl: false,
                            streetViewControl: false,
                            mapTypeControl: false,
                            fullscreenControl: false,
                        }}
                        onLoad={(map) => setMap(map)}
                    >
                        <Marker position={position} />

                        {directionsResponse && (
                            <DirectionsRenderer
                                directions={directionsResponse}
                            />
                        )}
                    </GoogleMap>
                </Box>
            </Flex>
        </>
    );
};
export default NationalParks;
