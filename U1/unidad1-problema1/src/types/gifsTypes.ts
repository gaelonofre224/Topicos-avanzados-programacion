export interface GifReference {
  id: string;
  title: string;
  url: string;
  username?: string;
}


export interface GiphyItem {
  id: string;
  title: string;
  username?: string;
  images: {
    downsized_medium: {
      url: string;
    };
  };
}