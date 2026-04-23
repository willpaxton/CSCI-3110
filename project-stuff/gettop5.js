// Authorization token that must have been created previously. See : https://developer.spotify.com/documentation/web-api/concepts/authorization
const token = 'BQCgQ0rvilICX4NuhGFhhhpXkTZMHVXRC7gJqqJCmtr2_uPMcJYd2NI5qC3ELL7PZvRDx9fPn3G01wnXZMR_NKk2bUm58ZvMOk-76Uegl76SzwcfF1qzmuPaui-VrZk3Fi8q4Pmsilk6PTSJe4KIK022Vivk-ccCNqkgG1W5sEkHsdFBXqHi4FeU5sibZcF_08TWa0RKie9MFESptq7PyDcKb2cMEEjn--E6Qkr1ITtwNmv9Tux1cR8stp9a-GRjZNwbC9dmFSa7jD-f30MnnKUS4LEotvmMCPsxU0gs9IXMEetQRCBmHwwAw_n8bRu-yZVDag';
async function fetchWebApi(endpoint, method, body) {
  const res = await fetch(`https://api.spotify.com/${endpoint}`, {
    headers: {
      Authorization: `Bearer ${token}`,
    },
    method,
    body:JSON.stringify(body)
  });
  return await res.json();
}

async function getTopTracks(){
  // Endpoint reference : https://developer.spotify.com/documentation/web-api/reference/get-users-top-artists-and-tracks
  return (await fetchWebApi(
    'v1/me/top/tracks?time_range=short_term&limit=5', 'GET'
  )).items;
}

const topTracks = await getTopTracks();
console.log(
  topTracks?.map(
    ({name, artists}) =>
      `${name} by ${artists.map(artist => artist.name).join(', ')}`
  )
);